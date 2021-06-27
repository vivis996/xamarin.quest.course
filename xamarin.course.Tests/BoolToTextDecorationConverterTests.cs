using Xamarin.Forms;
using Xunit;


namespace xamarin.course.Tests
{
    public class BoolToTextDecorationConverterTests
    {
        [Fact]
        public void Convert_returns_strikethrough_when_item_is_completed()
        {
            //Arrange
            BoolToTextDecorationConverter converter = new BoolToTextDecorationConverter();
            //Act
            object result = converter.Convert(true, null, null, null);
            //Assert
            Assert.Equal(TextDecorations.Strikethrough, (TextDecorations)result);
        }

        [Fact]
        public void Convert_returns_none_when_item_is_not_completed()
        {
            //Arrange
            BoolToTextDecorationConverter converter = new BoolToTextDecorationConverter();
            //Act
            object result = converter.Convert(false, null, null, null);
            //Assert
            Assert.Equal(TextDecorations.None, (TextDecorations)result);
        }
    }
}