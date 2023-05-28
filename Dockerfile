FROM mysql:8.0

# Set the root password for the MySQL server
ENV MYSQL_ROOT_PASSWORD <insert_password_here>

# Set the database name, username, and password
ENV MYSQL_DATABASE GreenBay
ENV MYSQL_USER greenbay
ENV MYSQL_PASSWORD <insert_password_here>

COPY init.sql /docker-entrypoint-initdb.d/