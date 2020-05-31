using System;
using System.Collections.Generic;
using System.Text;
using FundaAssignment.Entities;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace FundaAssignment.Repository
{
    class ObjectHttpResponseParser
    {
        public int TotaalAantalObjecten { get; set; }
        public List<Entities.Object> Objects { get; set; }
        public Paging Paging { get; set; }
    }

    class Paging
    {
        [JsonPropertyName("HuidigePagina")]
        public int CurrentPage { get; set; }
        [JsonPropertyName("AantalPaginas")]
        public int TotalPages { get; set; }

    }
}
