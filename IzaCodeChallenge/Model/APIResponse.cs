using System;
namespace IzaCodeChallenge.Model
{
    public class APIResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic? Data { get; set; }
    }
}

