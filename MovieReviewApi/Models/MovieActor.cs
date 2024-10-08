﻿using System.ComponentModel.DataAnnotations;

namespace MovieReviewApi.Models
{
    public class MovieActor
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }

        public Movie Movie { get; set; }
        public Person Actor { get; set; }
    }
}
