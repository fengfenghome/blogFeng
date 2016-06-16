using System.Configuration;


public class SetTitle
{
	public SetTitle()
	{
	
	}

    public static string getTitle()
    {
        return ConfigurationManager.AppSettings["title"].ToString();
    }
}
