﻿namespace Bridgeway;

/// <summary>
/// The exception that is thrown when a failure appeared in a broker operation.
/// </summary>
public class BrokerException : Exception
{
    public HttpResponseMessage? FailureResponse { get; }

    public BrokerException()
    {
    }

    public BrokerException(string? message) : base(message)
    {
    }

    public BrokerException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public BrokerException(HttpResponseMessage failureResponse)
    {
        FailureResponse = failureResponse;
    }

    public BrokerException(string? message, HttpResponseMessage failureResponse) : base(message)
    {
        FailureResponse = failureResponse;
    }
}