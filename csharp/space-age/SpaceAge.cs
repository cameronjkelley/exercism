public class SpaceAge
{
  public decimal Seconds { get; private set; }

  public SpaceAge(decimal seconds)
  {
    Seconds = seconds;
  }

  public decimal OnEarth()
  {
    return Seconds / 31557600;
  }

  public decimal OnMercury()
  {
    return OnEarth() / 0.2408467m;
  }

  public decimal OnVenus()
  {
    return OnEarth() / 0.61519726m;
  }

  public decimal OnMars()
  {
    return OnEarth() / 1.8808158m;
  }

  public decimal OnJupiter()
  {
    return OnEarth() / 11.862615m;
  }

  public decimal OnSaturn()
  {
    return OnEarth() / 29.447498m;
  }

  public decimal OnUranus()
  {
    return OnEarth() / 84.016846m;
  }

  public decimal OnNeptune()
  {
    return OnEarth() / 164.79132m;
  }
}
