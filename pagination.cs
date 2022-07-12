  public IEnumerable<ScoreViewModel> TopFiveScorersIn(string subjectName)
        {
            throw new NotImplementedException();
        }

        public PaginatedDataViewModel<TotalScoreViewModel> GetTotalScores(int startRow, int noOfRows)
        {
            int page = (startRow % noOfRows) + 1;


            var totalRows = students.Join(testScores, s => s.Id, ts => ts.StudentId, (s, ts) => new
            {
                ts.StudentId,
                StudentName = s.Name,
                ts.Marks
            })
            .GroupBy(e => new { e.StudentId, e.StudentName })
            .Select(e =>
            {
                var f = e;

                return new TotalScoreViewModel
                {
                    StudentId = e.Key.StudentId,
                    StudentName = e.Key.StudentName,
                    TotalMarks = e.Sum(a => a.Marks)
                };
            }).Skip((page - 1) * (noOfRows)).Take(noOfRows).ToList();

            var totalCount = students.Join(testScores, s => s.Id, ts => ts.StudentId, (s, ts) => new
            {
                ts.StudentId,
                StudentName = s.Name,
                ts.Marks
            })
            .GroupBy(e => new { e.StudentId, e.StudentName })
            .Select(e =>
            {
                var f = e;

                return new TotalScoreViewModel
                {
                    StudentId = e.Key.StudentId,
                    StudentName = e.Key.StudentName,
                    TotalMarks = e.Sum(a => a.Marks)
                };
            }).Count();


            var paginatingList = new PaginatedDataViewModel<TotalScoreViewModel>
            {
                TotalRows = totalCount,
                Rows = totalRows
            };

            return paginatingList;

        }
