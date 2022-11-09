package com.example.appthoitrang.Models;

public class Category {
    private Integer id;
    private String name;
    private String image;
    private String des;
    private String created_at;

    public Category() {
    }

    public Category(Integer id, String name, String image, String des, String created_at) {
        this.id = id;
        this.name = name;
        this.image = image;
        this.des = des;
        this.created_at = created_at;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getImage() {
        return image;
    }

    public void setImage(String image) {
        this.image = image;
    }

    public String getDes() {
        return des;
    }

    public void setDes(String des) {
        this.des = des;
    }

    public String getCreated_at() {
        return created_at;
    }

    public void setCreated_at(String created_at) {
        this.created_at = created_at;
    }
}
