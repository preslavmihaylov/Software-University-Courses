namespace ConsoleForum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entities.Posts;

    public class ModifiedForum : Forum
    {
        protected override void ExecuteCommandLoop()
        {
            this.Output.Clear();

            if (this.IsLogged)
            {
                this.Output.AppendLine(
                    string.Format(Messages.UserWelcomeMessage, this.CurrentUser.Username));
            }
            else
            {
                this.Output.AppendLine(Messages.GuestWelcomeMessage);
            }

            var hotQuestions = this.Questions
                .Where(q =>
                {
                    foreach (var answer in q.Answers)
                    {
                        if (answer is BestAnswer)
                        {
                            return true;
                        }
                    }

                    return false;
                });

            Dictionary<string, int> countOfAnswersOfUsers = new Dictionary<string, int>();

            foreach (var question in this.Questions)
            {
                foreach (var answer in question.Answers)
                {
                    if (countOfAnswersOfUsers.ContainsKey(answer.Author.Username))
                    {
                        countOfAnswersOfUsers[answer.Author.Username]++;
                    }
                    else
                    {
                        countOfAnswersOfUsers[answer.Author.Username] = 1;
                    }
                }
            }

            int activeUsersCount = 0;
            foreach (KeyValuePair<string, int> pair in countOfAnswersOfUsers)
            {
                if (pair.Value >= 3)
                {
                    activeUsersCount++;
                }
            }

            this.Output.AppendLine(
                string.Format(Messages.GeneralHeaderMessage, hotQuestions.Count(), activeUsersCount));

            Console.Write(this.Output);

            base.ExecuteCommandLoop();
        }
    }
}
