﻿using System.ComponentModel.DataAnnotations;

namespace LH.ManageProduct.Api.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string DepartmentCode { get; set; } = string.Empty;

        public decimal Price { get; set; } = decimal.Zero;

        public bool Status { get; set; } = true;
    }
}
