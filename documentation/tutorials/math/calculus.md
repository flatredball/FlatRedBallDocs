## Determining required magnitude for trajectory

The following method can be used to determine the required initial magnitude required for a fired object to pass through a point at RelativeX, RelativeY.

    private float CalculateRequiredStartingMagnitude(float relativeX, float relativeY, float desiredAngle, float gravity)
    {
        double topOfInsideOfSquareRoot = 2 * (relativeY * Math.Tan(desiredAngle) - relativeY);
        double squareRootPart = Math.Sqrt(topOfInsideOfSquareRoot / Math.Abs(gravity));
        double xVelocity = relativeY / squareRootPart;

        return (float)xVelocity / (float)Math.Cos(desiredAngle);
    }
