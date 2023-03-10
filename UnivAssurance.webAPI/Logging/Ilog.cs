namespace UnivAssurance.webAPI.Logging
{
    public interface Ilog
    {
        
            public  void Information( string msg);
            public void warning(string message);
            public void Error(string message);
            public void Debug(string message);
        
    }
}