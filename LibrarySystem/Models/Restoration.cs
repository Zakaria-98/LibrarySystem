﻿namespace LibrarySystem.Models
{
    public class Restoration
    {
        public int Id { get; set; }

        public DateTime RestorationDate { get; set; }

        public Order Order { get; set; }


    }
}
