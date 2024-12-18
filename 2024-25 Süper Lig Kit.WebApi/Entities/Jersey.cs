﻿namespace _2024_25_Süper_Lig_Kit.WebApi.Entities
{
    public class Jersey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public int TeamId { get; set; }
        public bool IsKeeper { get; set; }
        public Team Team { get; set; }
        public List<JerseyImage> JerseyImages { get; set; }
    }
}
