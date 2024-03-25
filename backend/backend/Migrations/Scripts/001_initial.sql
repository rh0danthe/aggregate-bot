
CREATE TABLE IF NOT EXISTS "Users" (
   "Id" serial PRIMARY KEY,
   "SessionString" text NOT NULL,
   "TgId" bigint NOT NULL,
   "Name" text NOT NULL
);

CREATE TABLE IF NOT EXISTS "ApprovedMessages" (
    "Id" serial PRIMARY KEY,
    "UserId" int REFERENCES "Users"("Id"),
    "Title" text ,
    "ChatId" bigint NOT NULL,
    "MessageId" bigint NOT NULL,
    "IsFound" boolean NOT NULL,
    "Content" text NOT NULL,
    "ChatName" text NOT NULL,
    "SenderName" text NOT NULL,
    "SenderContacts" text NOT NULL
);

