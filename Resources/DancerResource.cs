﻿using FullStack_Project_IE_2.Domain.Models;

namespace FullStack_Project_IE_2.Resources
{
    public class DancerResource
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public EClass ST { set; get; }
        public EClass LA { set; get; }
        public ERole role { set; get;}
    }
}
