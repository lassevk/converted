![.NET Core](https://github.com/lassevk/converted/workflows/.NET%20Core/badge.svg)

# Converted

This class library provides conversion functions between types, handling such nuances as nullable
types, enums, etc.

The purpose is to make it easy to convert values from one type to another, typically in reflection-
based code.

# Examples

    // Convert value of specific types to string
    string output1 = ValueConverter.Default.ConvertTo<string>(10);
    string output2 = ValueConverter.Default.ConvertTo<string>(true);
    string output3 = ValueConverter.Default.ConvertTo<string>(DateTime.Now);
    
    // output1 = "10"
    // output2 = "True"
    // output3 = "05.05.2020 22:10" (my timezone and culture)
    
    // Convert nullable values to enums (try doing this with Convert.ChangeType)
    [Flags]
    enum Test
    {
        A = 1,
        B = 2
    }
    Test? t = ValueConverter.Default.ConvertTo<Test?>((int?)3); // returns Test.A | Test.B
    