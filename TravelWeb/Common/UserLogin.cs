using System;

namespace TravelWeb.Common
{
    //Serializable Serialization là một quá trình để chuyển đổi một cấu trúc dữ liệu hoặc đối tượng thành một định dạng có thể lưu trữ được
    //ở đây dùng để lưu session của user
    [Serializable]
    public class UserLogin
    {
        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}