using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrityQuiz.Model
{
    public class AnswerRecord
    {
        public Actor CorrectActor { get; set; }
        public Actor SelectedActor { get; set; }
        public bool IsCorrect { get; set; }
    }
}
