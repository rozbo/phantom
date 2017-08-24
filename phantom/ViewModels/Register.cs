using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Azure.KeyVault.Models;
using phantom.Interfaces;

namespace phantom.ViewModels
{
    public class Register
    {


        [Required(ErrorMessage = "{0}必须填写。")]
        [EmailAddress]
        [Display(Name="邮箱地址")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0}必须填写。")]
        [StringLength(18, MinimumLength = 6,ErrorMessage = "{0} 必须大于 {1} 位，但最多不超过{2}位")]
        [Display(Name="密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0}必须填写。")]
        [DataType(DataType.Password)]
        [Display(Name="重复一下上面你输入的密码")]
        [Compare("Password",ErrorMessage = "{0}与{1}不一致")]
        public string ConfirmPassword { get; set; }

        public bool Agree { get; set; }
    }

}