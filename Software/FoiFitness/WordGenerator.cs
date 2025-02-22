using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Words;
using Aspose.Words.XAttr;
using DataAccessLayer;
using iTextSharp.text.pdf;

namespace FoiFitness
{
    public class WordGenerator
    {
        public static string GeneratePlanSummary(TrainingPlan plan)
        {
            string filename = $"{plan.name}.docx";

            Document doc = new Document();
            Paragraph title = new Paragraph(doc);

            title.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading1;
            title.AppendChild(new Run(doc, plan.name));
            doc.FirstSection.Body.AppendChild(title);

            Paragraph planDesc = new Paragraph(doc);

            planDesc.AppendChild(new Run(doc, $"{plan.description}\n\r"));
            planDesc.AppendChild(new Run(doc, $"Plan Goal: {plan.PlanType.name}\n\r"));

            doc.FirstSection.Body.AppendChild(planDesc);
            doc.FirstSection.Body.AppendChild(new Paragraph(doc));

            var trainingCounter = 1;
            foreach(var training in plan.Trainings)
            {
                
                Paragraph trainingTitle = new Paragraph(doc);
                trainingTitle.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading3;
                trainingTitle.AppendChild(new Run(doc, $"Training {trainingCounter} - {training.Day.date} ({DateTime.ParseExact(training.Day.date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).DayOfWeek})"));
                doc.FirstSection.Body.AppendChild(trainingTitle);

                Paragraph exerciseInfo = new Paragraph(doc);
                exerciseInfo.AppendChild(new Run(doc, "Exercises:"));

                foreach (var exercise in training.Training_Exercises)
                {
                    exerciseInfo.AppendChild(new Run(doc, $"Name: {exercise.Exercis.name}\n\r"));
                    exerciseInfo.AppendChild(new Run(doc, $"Description: {exercise.Exercis.description}\n\r"));
                    exerciseInfo.AppendChild(new Run(doc, $"Body part: {exercise.Exercis.BodyPart.name}\n\r"));
                    exerciseInfo.AppendChild(new Run(doc, $"Sets: {exercise.sets}\n\r"));
                    exerciseInfo.AppendChild(new Run(doc, $"Repetitions: {exercise.repetition}\n\n"));
                }
                doc.FirstSection.Body.AppendChild(exerciseInfo);
                trainingCounter++;
            }


            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string fullFilePath = $"{downloadsPath}\\{filename}";

            doc.Save(fullFilePath);
            Debug.WriteLine("File created successfully!");
            return fullFilePath;
           
        }
    }
}
