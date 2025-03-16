CREATE TABLE bug_report (
  id SERIAL NOT NULL PRIMARY KEY,
  uuid UUID NOT NULL,
  title VARCHAR(255) NOT NULL,
  detail TEXT NOT NULL,
  created_at timestamp with time zone NOT NULL,
  updated_at timestamp with time zone,
  deleted_at timestamp with time zone
);

CREATE INDEX ON bug_report (uuid);
