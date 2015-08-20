namespace RestSharp.Extensions
{
    using System;
    using System.Net;

    public static class ResponseStatusExtensions
    {
        /// <summary>
        /// Convert a <see cref="ResponseStatus"/> to a <see cref="WebException"/> instance.
        /// </summary>
        /// <param name="responseStatus">The response status.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">responseStatus</exception>
        public static WebException ToWebException(this ResponseStatus responseStatus)
        {
            WebException exception;
            string message;
            switch (responseStatus)
            {
                case ResponseStatus.None:
                    message = "The request could not be processed.";
#if !SILVERLIGHT
                    exception = new WebException(message, WebExceptionStatus.ServerProtocolViolation);
#else
                    exception = new WebException(message, WebExceptionStatus.UnknownError);
#endif
                    break;

                case ResponseStatus.Error:
                    message = "An error occurred while processing the request.";
#if !SILVERLIGHT
                    exception = new WebException(message, WebExceptionStatus.ServerProtocolViolation);
#else
                    exception = new WebException(message, WebExceptionStatus.UnknownError);
#endif
                    break;

                case ResponseStatus.TimedOut:
                    message = "The request timed-out.";
#if !SILVERLIGHT
                    exception = new WebException(message, WebExceptionStatus.Timeout);
#else
                    exception = new WebException(message, WebExceptionStatus.UnknownError);
#endif
                    break;

                case ResponseStatus.Aborted:
                    message = "The request was aborted.";
#if !SILVERLIGHT
                    exception = new WebException(message, WebExceptionStatus.Timeout);
#else
                    exception = new WebException(message, WebExceptionStatus.RequestCanceled);
#endif
                    break;

                default:
                    throw new ArgumentOutOfRangeException("responseStatus");
            }

            return exception;
        }
    }
}
