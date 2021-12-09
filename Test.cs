using System.Threading.Tasks;

public abstract class Test {
    protected Driver driver;

    public Driver Driver {
        set => driver = value;
    }

    public void Before() {
    }

    public void After() {
        driver.Close();
    }
}