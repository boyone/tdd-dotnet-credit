namespace Credit.Tests;

public class CreditTest
{
    [Fact]
    public void วงเงินสินเชื่อ_100_000_ใช้ไป_70_000_ขอใช้เพิ่ม_20_000_ผลการอนุมัติ_ผ่าน()
    {
        // Arrange
        bool expectedResult = true;
        ISAP sapStub = new SAPStub(100000, 70000);
        Credit credit = new Credit(sapStub);

        // Act
        bool actualResult = credit.RequestForApproval("11441", 20000);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void วงเงินสินเชื่อ_100_000_ใช้ไป_80_000_ขอใช้เพิ่ม_20_000_ผลการอนุมัติ_ผ่าน()
    {
        // Arrange
        bool expectedResult = true;
        ISAP sapStub = new SAPStub(100000, 80000);
        Credit credit = new Credit(sapStub);

        // Act
        bool actualResult = credit.RequestForApproval("15320", 20000);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void วงเงินสินเชื่อ_100_000_ใช้ไป_50_000_ขอใช้เพิ่ม_60_000_ผลการอนุมัติ_ไม่ผ่าน()
    {
        // Arrange
        bool expectedResult = false;
        ISAP sapStub = new SAPStub(100000, 50000);
        Credit credit = new Credit(sapStub);

        // Act
        bool actualResult = credit.RequestForApproval("15329", 60000);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

}

public class SAPStub : ISAP // MOQ
{
    public SAPStub(int customerCredit, int usedCredit)
    {
        this.customerCredit = customerCredit;
        this.usedCredit = usedCredit;
    }

    public int customerCredit {get; set;}
    public int usedCredit {get; set;}
    public CreditLimit getCreditLimit(string customerCode)
    {
        return new CreditLimit(customerCredit, usedCredit);
    }
}


// Constructor
// Setter
// Argument