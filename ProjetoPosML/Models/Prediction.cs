using System;
using Microsoft.ML.Data;

namespace ProjetoPosML.Models
{
    public class Prediction
    {
        [ColumnName("Score")]
        public float Price { get; set; }
    }
}
