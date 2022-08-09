using SchoolCore.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCore.app
{
    public class Report
    {
        Dictionary<KeysDictionary, IEnumerable<ObjSchoolBase>> _dictionary;
        public Report(Dictionary<KeysDictionary, IEnumerable<ObjSchoolBase>> dicc)
        {

            if (dicc == null)
            {
                throw new ArgumentNullException(nameof(dicc));
            }
            _dictionary = dicc;
        }

        public IEnumerable<Evaluation> GetListEvaluation()
        {
            IEnumerable<School> rta;
            if (_dictionary.TryGetValue(KeysDictionary.Evaluation, out IEnumerable<ObjSchoolBase> list))
            {
                return list.Cast<Evaluation>();
            }
            { return new List<Evaluation>(); }
        }

        #region sobrecarga
        public IEnumerable<string> GetListSubjects()
        {
            return GetListEvaluation().Select(item => item.Subject.Name).Distinct();
        }

        public IEnumerable<string> GetListSubjects(out IEnumerable<Evaluation> list)
        {
            list = GetListEvaluation();
            return list.Select(item => item.Subject.Name).Distinct();
        }
        #endregion

        public Dictionary<string, IEnumerable<Evaluation>> GetEvalXSubjects()
        {
            var rta = new Dictionary<string, IEnumerable<Evaluation>>();
            var listSubject = GetListSubjects(out var listEval);
            foreach (var subject in listSubject)
            {
                var evalAsing = listEval.Where(ev => ev.Subject.Name == subject).Select(item => item);
                rta.Add(subject, evalAsing);
            }
            return rta;
        }


        public Dictionary<string, IEnumerable<StudentEvaluation>> GetAvegarageStudentEvaluation()
        {
            var studentEvaluationEnd = new Dictionary<string, IEnumerable<StudentEvaluation>>();
            var diccEvalForSubject = GetEvalXSubjects();
            foreach (var item in diccEvalForSubject)
            {
                var resultEvaluation = item.Value.GroupBy(item =>
              new { UniqueID = item.Student.UniqueID, StudentName = item.Student.Name, Subjectname = item.Name }).Select(it => new StudentEvaluation
              {
                  StudentID = it.Key.UniqueID,
                  StudentName = it.Key.StudentName,
                  Average = it.Average(ev => ev.Note),
                  Subject = it.Key.Subjectname

              });
                studentEvaluationEnd.Add(item.Key, resultEvaluation);
            }
            return studentEvaluationEnd;
        }

        public Dictionary<string, IEnumerable<StudentEvaluation>> GetTopAverage(int top = 1)
        {
            var studentAverageTop = new Dictionary<string, IEnumerable<StudentEvaluation>>();
            var daverageStudents= GetAvegarageStudentEvaluation();
            foreach (var item in daverageStudents)
            {
                var filter = item.Value.OrderByDescending(it => it.Average).Take(top);
                studentAverageTop.Add(item.Key, filter);
            }

            return studentAverageTop;
        }


    }
}
