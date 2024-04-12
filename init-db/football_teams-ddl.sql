CREATE TABLE football_teams
(
    id               SERIAL PRIMARY KEY,
    name             VARCHAR(100) NOT NULL,
    founded_at       DATE         NOT NULL,
    city             VARCHAR(100) NOT NULL,
    country          VARCHAR(100) NOT NULL,
    stadium          VARCHAR(100),
    stadium_capacity INT
);

