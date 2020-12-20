using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClipMoney.Models
{
    
    public class Resp
    {
        string token;
        int id;
        public Resp(string token, int id)
        {
            this.token = token;
            this.id = id;
        }

        public int ID { get => this.id; set => this.id = value; }
        public string Token { get => this.token; set => this.token = value; }
    }
}