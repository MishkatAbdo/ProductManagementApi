﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApplication.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
