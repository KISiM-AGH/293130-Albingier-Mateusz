﻿namespace FullStack_Project_IE_2.Domain.Services.Communication
{
    public abstract class BaseResponse
    {

        public bool Success { get; protected set;}
        public string Message { get; protected set;}

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
