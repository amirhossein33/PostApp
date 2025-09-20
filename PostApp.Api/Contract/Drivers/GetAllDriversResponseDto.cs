namespace PostApp.Api.Contract.Drivers;

public class GetAllDriversResponseDto
{
    public IEnumerable<DriverResponseDto> Drivers { get; set; } = new List<DriverResponseDto>();
}