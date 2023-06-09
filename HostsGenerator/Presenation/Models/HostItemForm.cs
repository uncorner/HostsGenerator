﻿using HostsGenerator.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HostsGenerator.Presenation.Models
{
    public class HostItemForm
    {
        private const string DomainPattern = @"^\s*[0-9a-zA-Z]+\.[a-zA-Z]+\s*$";

        [Display(Name = "Описание")]
        [StringLength(50, ErrorMessage = "Слишком много символов")]
        public string? Description { get; set; }

        [Display(Name = "Домен хоста")]
        [Required(ErrorMessage = "Введите домен хоста")]
        [RegularExpression(DomainPattern, ErrorMessage = "Неверный формат домена")]
        [StringLength(255, ErrorMessage = "Слишком много символов")]
        [Remote(nameof(HostItemController.CheckDomainExists),
            "HostItem", ErrorMessage = "Хост с таким доменом уже был добавлен")]
        public string Domain { get; set; } = string.Empty;

        [Display(Name = "Применяется")]
        public bool IsEnabled { get; set; } = true;

    }
}
