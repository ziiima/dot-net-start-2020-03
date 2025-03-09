CREATE TABLE users (
    id SERIAL NOT NULL,
    uuid UUID NOT NULL,
    name VARCHAR(255) NOT NULL,
    created_at TIMESTAMP,
    updated_at TIMESTAMP,
    deleted_at TIMESTAMP,
    PRIMARY KEY (uuid)
);
