using BusinessLogicLayer;
using DataAccessLayer;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoiFitness
{
    public static class PDFGenerator
    {
        public static byte[] GeneratePDF(TrainingPlan trainingPlan)
        {
            using (var ms = new MemoryStream())
            {
                using (var document = new Document())
                {
                    PdfWriter.GetInstance(document, ms);
                    document.Open();
                    document.Add(new Paragraph("Training plan: " + trainingPlan.name));
                    document.Add(new Paragraph("----------------------------------"));
                    document.Add(new Paragraph("Description: " + trainingPlan.description));
                    document.Add(new Paragraph("----------------------------------"));
                    document.Add(new Paragraph("Plan type: " + trainingPlan.PlanType.name));
                    document.Add(new Paragraph("----------------------------------"));
                    foreach (var training in trainingPlan.Trainings)
                    {
                        document.Add(new Paragraph("----------------------------------"));
                        document.Add(new Paragraph("Exercises: "));
                        int i = 0;
                        foreach (var exercise in training.Training_Exercises)
                        {
                            i++;
                            document.Add(new Paragraph(i + ". Exercise: "));
                            document.Add(new Paragraph("Name: " + exercise.Exercis.name));
                            document.Add(new Paragraph("Description: " + exercise.Exercis.description));
                            document.Add(new Paragraph("Body part: " + exercise.Exercis.BodyPart.name));
                            document.Add(new Paragraph("Equipment: " + exercise.Exercis.Equipment.name));
                            document.Add(new Paragraph("Difficulty: " + exercise.Exercis.difficulty.ToString()));
                            document.Add(new Paragraph("Duration: " + exercise.duration.ToString()));
                            document.Add(new Paragraph("Sets: " + exercise.sets.ToString()));
                            document.Add(new Paragraph("Repetitions: " + exercise.repetition.ToString()));
                            document.Add(new Paragraph("----------------------------------"));
                        }
                    }
                    document.Close();
                }
                return ms.ToArray();
            }
        }
    }
}
