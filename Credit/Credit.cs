namespace Credit;
public class Credit
{
    ISAP sap;

    public Credit(ISAP sap)
    {
        this.sap = sap;
    }

    public bool RequestForApproval(string customerCode, int tripAmount) {
        CreditLimit creditLimit = sap.getCreditLimit(customerCode);
        
        return creditLimit.customerCredit >= creditLimit.usedCredit + tripAmount;
    }
}

public interface ISAP 
{
    public CreditLimit getCreditLimit(string customerCode);
}

public class CreditLimit
{
    public CreditLimit(int customerCredit, int usedCredit)
    {
        this.customerCredit = customerCredit;
        this.usedCredit = usedCredit;
    }

    public int customerCredit {get; set;}
    public int usedCredit {get; set;}    
}