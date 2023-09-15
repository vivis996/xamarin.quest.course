using xamarin.quest.course.Converters;
using Xamarin.Forms;

namespace xamarin.quest.course.tests.Converters;

public class BoolToTextDecorationConverterTests
{
    [Fact]
    public void Convert_WhenCalled_StrikethroughWhenItemIsCompleted()
    {
        var converter = new BoolToTextDecorationConverter();
        var result = converter.Convert(true, null, null, null);

        Assert.Equal(TextDecorations.Strikethrough, (TextDecorations)result);
    }

    [Fact]
    public void Convert_WhenCalled_StrikethroughWhenItemIsNotCompleted()
    {
        var converter = new BoolToTextDecorationConverter();
        var result = converter.Convert(false, null, null, null);

        Assert.Equal(TextDecorations.None, (TextDecorations)result);
    }
}
