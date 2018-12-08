using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace EsiTest.WebRequest
{
    public class RequestPage : IDisposable
    {
        private const string RequestUrl = "https://www.reddit.com";
        private readonly HttpClient _client;

        public RequestPage()
        {
            _client = new HttpClient();
        }

        public async Task<string> MakeBasicRequest(CancellationToken token)
        {
            // This method is making a HTTP get request to reddit.com to get the main homepage of reddit.
            // We are using HTTPS (SSL) because it is required by the host, an http request gets redirected to HTTPS by default.

            // REQUEST HEADER:
            // The request header is used to hold a few pieces of information:
            // The source (ip address / port)
            // The requested URI (ex: http://www.reddit.com/r/programming")
            // Content type (json, html, text etc)
            // The "user-agent" such as what kind of browser are you using.
            // There are many more fields, but those are the typically ones used.
            // The verb & http version. (Post, Put, Get, Delete etc)

            // REQUEST BODY:
            // The request body contains information on what is being sent in addition to the header
            // for example if you're doing a JSON post, the body would contain the JSON being pushed to the server
            // or if you're doing a form post, the form data.

            // REQUEST METHOD:
            // The request method are the verbs that are to be performed to a web server.
            // Common operations (referred to as CRUD operations):
            // GET - Get's data from the specified resource, should be readonly
            // POST - Push data up to the server.
            // PUT - Push data up to the server, but should also replace the target object (think of an update / overwrite).
            // DELETE - Deletes the specified item being requested
            // There are additional methods / types that are less commonly used such as: CONNECT or PATCH

            // RESPONSE HEADER:
            // When a request is made, the first thing returned is the response header:
            // THe response header has the response code (ex 404: not found)
            // the content-type  ( ex text / html)

            // RESPONSE BODY:
            // Same as the request body, based on the content type, it can contain different things
            // it could be images, json, xml, html, or even raw text.

            Uri requestUri = new Uri(RequestUrl);
            
            var response = await _client.GetAsync(requestUri, token);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return $"Error occurred: {response.ReasonPhrase}";   
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _client.Dispose();
            }
        }
    }
}