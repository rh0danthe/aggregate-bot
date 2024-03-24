CREATE TABLE IF NOT EXISTS "ApprovedMessages" (
    "Id" serial PRIMARY KEY,
    "Title" text NOT NULL,
    "SessionString" text NOT NULL,
    "ChatId" bigint NOT NULL,
    "MessageId" bigint NOT NULL,
    "IsFound" boolean NOT NULL,
    "Content" text NOT NULL
);
