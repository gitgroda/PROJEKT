    public class HeavyPhysics : IClimberPhysics
    {
        private int _jumpTicksLeft = 0;

        public void Move(Climber climber, int deltaX, Map map)
        {
            Position pos = climber.GetPosition();
            Position target = new Position(pos.X + deltaX, pos.Y);
            // Strikt markbunden: kan absolut inte styra eller glida i luften
            if (map.IsWalkable(target) && map.HasGroundBelow(target))
            {
                climber.MoveTo(target);
            }
        }

        public void Climb(Climber climber, int deltaY, Map map)
        {
            Position pos = climber.GetPosition();
            Position target = new Position(pos.X, pos.Y + deltaY);
            if (map.IsLadder(target) || map.IsLadder(pos))
            {
                climber.MoveTo(target);
            }
        }

        public void Jump(Climber climber, Map map)
        {
            Position pos = climber.GetPosition();
            // Lågt och tungt minihopp (endast 2 steg, kräver skicklighet)
            if (map.HasGroundBelow(pos) && _jumpTicksLeft == 0)
            {
                _jumpTicksLeft = 2;
            }
        }

        public void Update(Climber climber, Map map)
        {
            Position pos = climber.GetPosition();
            if (map.IsLadder(pos)) return;

            if (_jumpTicksLeft > 0)
            {
                if (map.IsWalkable(pos.GetAbove())) climber.MoveTo(pos.GetAbove());
                _jumpTicksLeft--;
                return;
            }

            // Snabb och direkt gravitation mot marken utan fördröjning
            if (!map.HasGroundBelow(pos))
            {
                Position below = pos.GetBelow();
                if (map.IsWalkable(below)) climber.MoveTo(below);
            }
        }
    }