using System;
using System.Net.NetworkInformation;

public class EmptySearchTermException : Exception
{
    public EmptySearchTermException() : base("Search term cannot be empty.")
    {
    }

    public EmptySearchTermException(string message) : base(message)
    {
    }

    public EmptySearchTermException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

