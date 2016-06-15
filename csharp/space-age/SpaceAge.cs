using System.Collections.Generic;

public class SpaceAge
{
  private enum Planet
  {
    Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune
  }
  public decimal Seconds { get; private set; }

  public SpaceAge(decimal seconds)
  {
    Seconds = seconds;
  }

  private Dictionary<Planet, decimal> PlanetaryPeriods = new Dictionary<Planet, decimal>
  {
    { Planet.Mercury, 0.2408467m },
    { Planet.Venus, 0.61519726m },
    { Planet.Earth, 1 },
    { Planet.Mars, 1.8808158m },
    { Planet.Jupiter, 11.862615m },
    { Planet.Saturn, 29.447498m },
    { Planet.Uranus, 84.016846m },
    { Planet.Neptune, 164.79132m }
  };

  public decimal OnMercury()
  {
    return OnPlanetX(PlanetaryPeriods[Planet.Mercury]);
  }

  public decimal OnVenus()
  {
    return OnPlanetX(PlanetaryPeriods[Planet.Venus]);
  }

  public decimal OnEarth()
  {
    return OnPlanetX(PlanetaryPeriods[Planet.Earth]);
  }

  public decimal OnMars()
  {
    return OnPlanetX(PlanetaryPeriods[Planet.Mars]);
  }

  public decimal OnJupiter()
  {
    return OnPlanetX(PlanetaryPeriods[Planet.Jupiter]);
  }

  public decimal OnSaturn()
  {
    return OnPlanetX(PlanetaryPeriods[Planet.Saturn]);
  }

  public decimal OnUranus()
  {
    return OnPlanetX(PlanetaryPeriods[Planet.Uranus]);
  }

  public decimal OnNeptune()
  {
    return OnPlanetX(PlanetaryPeriods[Planet.Neptune]);
  }

  private decimal OnPlanetX(decimal period)
  {
    decimal earthPeriod = 31557600;
    return (Seconds / earthPeriod) / period;
  }
}