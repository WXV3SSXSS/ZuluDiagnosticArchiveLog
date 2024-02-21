using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace zuluFINALS
{
	internal class DiagnosticArchiveLog
	{
		//?????
		const double CRITICAL_COEFFICIENT = 0.20;
		public string Region { get; set; }
		public DistrictEnum District { get; set; }
		public DateTime DateOfExamenation { get; set; }
		public decimal RegionLenght { get; set; }
		public decimal Diameter { get; set; }
		public TypeOfPipelineEnum TypeOfPipeline { get; set; }
		public DateTime DateOfCommissioning { get; set; }
		public double CoefficientOfEmergencyDanger { get; set; }
		public int OperatingTimeToFailure { get; set; }
		public bool PresenceOfSubcriticalDefects { get; set; }
		public bool PresenceOfCriticalDefects { get; set; }
		public decimal LengthOfCriticalDefects { get; set; }

		int diagnosticResults = 0;
		List<string> diagnosticResultList = new List<string>() {
		   "1.\tОтсутствуют критические дефекты;",
		   "2.\tКритические дефекты - до 5% от протяженности участка теплосети;",
		   "3.\tКритические дефекты - от 5 до 10%протяженности участка теплосети;",
		   "4.\tКритические дефекты - от 10% до 20% от протяженности  участка теплосети;",
		   "5.\tКритические дефекты - более 20% от протяженности участка теплосети."
		};
		public string DiagnosticResult { get { return diagnosticResultList[diagnosticResults]; } }
        public string Comment { get; set; }
        public string Person { get; set; }
        public int FinallScore { get; set; }
		public DiagnosticArchiveLog(string region, DistrictEnum district, DateTime dateOfExamenation,
			decimal regionLenght, decimal diameter, TypeOfPipelineEnum typeOfPipeline, 
			DateTime dateOfCommissioning, double coefficient, int operatingTimeToFailure,
			bool subcriticalDefects, bool criticalDefects, decimal lenghtOfCriticalDefects,
			int diagnosticResults, string comment, string person)
		{
			Region = region;
			District = district;
			DateOfExamenation = dateOfExamenation;
			RegionLenght = regionLenght;
			Diameter = diameter;
			TypeOfPipeline = typeOfPipeline;
			DateOfCommissioning = dateOfCommissioning;
			CoefficientOfEmergencyDanger = coefficient;
			OperatingTimeToFailure = operatingTimeToFailure;
			PresenceOfSubcriticalDefects = subcriticalDefects;
			PresenceOfCriticalDefects = criticalDefects;
			LengthOfCriticalDefects = lenghtOfCriticalDefects;
			this.diagnosticResults = diagnosticResults;
			Comment = comment;
			Person = person;
			CalculateFinallScore();
		}
		public DiagnosticArchiveLog() { }
		public void Initialization(string region, DistrictEnum district, DateTime dateOfExamenation,
			decimal regionLenght, decimal diameter, TypeOfPipelineEnum typeOfPipeline,
			DateTime dateOfCommissioning, double coefficient, int operatingTimeToFailure,
			bool subcriticalDefects, bool criticalDefects, decimal lenghtOfCriticalDefects,
			int diagnosticResults, string comment, string person)
		{
			Region = region;
			District = district;
			DateOfExamenation = dateOfExamenation;
			RegionLenght = regionLenght;
			Diameter = diameter;
			TypeOfPipeline = typeOfPipeline;
			DateOfCommissioning = dateOfCommissioning;
			CoefficientOfEmergencyDanger = coefficient;
			OperatingTimeToFailure = operatingTimeToFailure;
			PresenceOfSubcriticalDefects = subcriticalDefects;
			PresenceOfCriticalDefects = criticalDefects;
			LengthOfCriticalDefects = lenghtOfCriticalDefects;
			this.diagnosticResults = diagnosticResults;
			Comment = comment;
			Person = person;
			CalculateFinallScore();
		}
		public void CalculateFinallScore()
		{
			if (CoefficientOfEmergencyDanger < 0.8 * CRITICAL_COEFFICIENT)
			{
				if (PresenceOfCriticalDefects == false && PresenceOfSubcriticalDefects == false)
				{
					FinallScore = 0;
				}
				if (PresenceOfCriticalDefects == false && PresenceOfSubcriticalDefects == true)
				{
					FinallScore = 1;
				}
				if (PresenceOfCriticalDefects == true)
				{
					FinallScore = 3;
				}
			}
			else if(CoefficientOfEmergencyDanger >= 0.8 * CRITICAL_COEFFICIENT
				&& CoefficientOfEmergencyDanger < CRITICAL_COEFFICIENT){
				FinallScore = 4;
			}
			else if(CoefficientOfEmergencyDanger >= CRITICAL_COEFFICIENT)
			{
				FinallScore = 5;
			}
		}
    }
}
