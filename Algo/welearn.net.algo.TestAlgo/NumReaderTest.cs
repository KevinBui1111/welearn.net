using welearn.net.algo.piece;

namespace welearn.net.algo.TestAlgo;

public class NumReaderTest {

    [Theory]
    // Edge cases: Null, Empty, Zero
    [InlineData(null, "không")]
    [InlineData("", "không")]
    [InlineData("   ", "không")]
    [InlineData("0", "không")]
    [InlineData("000", "không")]

    // Single digits
    [InlineData("5", "năm")]
    [InlineData("1", "một")]

    // Tens (mười vs mươi, lăm vs năm, mốt vs một)
    [InlineData("10", "mười")]
    [InlineData("11", "mười một")]
    [InlineData("15", "mười lăm")]
    [InlineData("21", "hai mươi mốt")]
    [InlineData("25", "hai mươi lăm")]
    [InlineData("50", "năm mươi")]

    // Hundreds (trăm, lẻ)
    [InlineData("100", "một trăm")]
    [InlineData("101", "một trăm lẻ một")]
    [InlineData("105", "một trăm lẻ năm")]
    [InlineData("115", "một trăm mười lăm")]
    [InlineData("121", "một trăm hai mươi mốt")]

    // Large groups (nghìn, triệu, tỷ)
    [InlineData("1000", "một nghìn")]
    [InlineData("1200", "một nghìn hai trăm")]
    [InlineData("123456000", "một trăm hai mươi ba triệu bốn trăm năm mươi sáu nghìn")]
    [InlineData("23456000", "hai mươi ba triệu bốn trăm năm mươi sáu nghìn")]
    [InlineData("3005000", "ba triệu không trăm lẻ năm nghìn")]
    [InlineData("505000", "năm trăm lẻ năm nghìn")]
    [InlineData("120300", "một trăm hai mươi nghìn ba trăm")]
    [InlineData("21301", "hai mươi mốt nghìn ba trăm lẻ một")]
    [InlineData("11521", "mười một nghìn năm trăm hai mươi mốt")]
    [InlineData("55000025", "năm mươi lăm triệu không trăm hai mươi lăm")]

    [InlineData("1000000", "một triệu")]
    [InlineData("10000000", "mười triệu")]
    [InlineData("500000", "năm trăm nghìn")]
    [InlineData("1000000000", "một tỷ")]
    [InlineData("2199285001", "hai tỷ một trăm chín mươi chín triệu hai trăm tám mươi lăm nghìn không trăm lẻ một")]
    [InlineData("1000000000000", "một nghìn tỷ")]

    // Input formatting
    [InlineData("  123  ", "một trăm hai mươi ba")] // Spaces
    [InlineData("00123", "một trăm hai mươi ba")]    // Leading zeros
    public void ReadNum_ShouldReturnCorrectVietnameseWords(string input, string expected)
    {
        // Act
        var result = NumReader.Read(input);

        // Assert
        Assert.Equal(expected, result);
    }
}