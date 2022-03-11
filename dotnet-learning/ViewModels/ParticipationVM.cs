namespace dotnetlearning.ViewModels
{
    public class ParticipationVM // Diferente de todos os outros view models porque daria conflito com o model de Participation caso não mudasse o nome
    {
        public int PlayerId { get; set; }
        public int Score { get; set; }
    }
}
