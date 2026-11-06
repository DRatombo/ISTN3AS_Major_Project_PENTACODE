using Cafe101;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;

namespace Cafe101.Web
{
    public class ChatHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            var js = new JavaScriptSerializer();

            string body;
            using (var r = new StreamReader(context.Request.InputStream))
                body = r.ReadToEnd();

            var req = js.Deserialize<ChatRequest>(body) ?? new ChatRequest();

            string msg = (req.message ?? "").Trim();
            if (msg.Length > 300) msg = msg.Substring(0, 300);

            //string reply = SmartChatbotHelper.GetResponse(msg);
            //context.Response.Write(js.Serialize(new { reply = reply }));
            try
            {
                string reply = SmartChatbotHelper.GetResponse(msg);
                context.Response.Write(js.Serialize(new { reply = reply }));
            }
            catch (System.Exception ex)
            {
                context.Response.Write(js.Serialize(new { reply = "ERROR: " + ex.Message }));
            }
        }

        public bool IsReusable { get { return false; } }
    }

    public class ChatRequest { public string message { get; set; } }

}