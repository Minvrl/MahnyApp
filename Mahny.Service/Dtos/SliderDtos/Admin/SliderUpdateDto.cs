using FluentValidation;
using Mahny.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahny.Service.Dtos.SliderDtos.Admin
{
    public class SliderUpdateDto
    {
        
        public string PrimaryText { get; set; }
        public string SecondaryText { get; set; }
        public IFormFile? File { get; set; }
        public int Order { get; set; }
    }
    public class SliderUpdateDtoValidator : AbstractValidator<SliderUpdateDto>
    {
        public SliderUpdateDtoValidator()
        {
            RuleFor(x => x.PrimaryText)
                .NotEmpty().MinimumLength(5);
            RuleFor(x => x.PrimaryText)
                .NotEmpty().MinimumLength(10);
            RuleFor(x => x).Custom((f, c) =>
            {
                if (f.File != null && f.File.Length > 2 * 1024 * 1024)
                {
                    c.AddFailure("File", "File must be less or equal than 2MB");
                }
            });

        }
    }
}
