using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RVP.Core.Domain.Entities.BasicEntities;

namespace RVP.Core.Domain.Entities
{
   public class Votes: BasicEntity
    {
        
        public required int IdCitizen { get; set; }
        public required int? IdElectionCandidate { get; set; } //Candidate in position  for vote
        public required bool VoteNoOne { get; set; } //To know if the vote is for no one
        public required int IdElectionPosition { get; set; } //Position for vote 

        public  ElectionCandidates? ElectionCandidates { get; set; }
        public  Citizen? Citizen { get; set; }
        public  ElectionPosition? ElectionPosition { get; set; }


    }
}
