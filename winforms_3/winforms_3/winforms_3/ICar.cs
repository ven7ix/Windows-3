namespace winforms_3
{
    public interface ICar
    {
        string m_brand { get; set; }
        string m_model { get; set; }
        int m_power { get; set; }
        int m_maxSpeed { get; set; }
        string m_type { get; set; }
        string m_licencePlate { get; set; }
    }
}
