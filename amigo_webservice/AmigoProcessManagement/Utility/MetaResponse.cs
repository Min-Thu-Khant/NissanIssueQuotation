using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmigoProcessManagement.Utility
{
    public class MetaResponse
    {
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private dynamic data;

        public dynamic Data
        {
            get { return data; }
            set { data = value; }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        //phase 2 added
        public MetaResponse()
        {
            Meta = new Meta();
        }
        public Meta Meta { get; set; }

    }
}