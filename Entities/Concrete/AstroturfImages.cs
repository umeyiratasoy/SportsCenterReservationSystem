﻿using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class AstroturfImage : IEntity
    {
        public int Id { get; set; }
        public int AstroturfId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
