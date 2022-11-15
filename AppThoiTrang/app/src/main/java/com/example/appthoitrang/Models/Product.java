package com.example.appthoitrang.Models;

public class Product {
    private int id;
    private String name;
    private String image;
    private int quantity;
    private double price;
    private double sale_price;
    private String des;
    private String size;
    private String color;
    private String hang_san_xuat;
    private int view;

    public Product() {
    }

    public Product(int id, String name, String image, int quantity, double price, double sale_price, String des, String size, String color, String hang_san_xuat, int view) {
        this.id = id;
        this.name = name;
        this.image = image;
        this.quantity = quantity;
        this.price = price;
        this.sale_price = sale_price;
        this.des = des;
        this.size = size;
        this.color = color;
        this.hang_san_xuat = hang_san_xuat;
        this.view = view;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
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

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public double getSale_price() {
        return sale_price;
    }

    public void setSale_price(double sale_price) {
        this.sale_price = sale_price;
    }

    public String getDes() {
        return des;
    }

    public void setDes(String des) {
        this.des = des;
    }

    public String getSize() {
        return size;
    }

    public void setSize(String size) {
        this.size = size;
    }

    public String getColor() {
        return color;
    }

    public void setColor(String color) {
        this.color = color;
    }

    public String getHang_san_xuat() {
        return hang_san_xuat;
    }

    public void setHang_san_xuat(String hang_san_xuat) {
        this.hang_san_xuat = hang_san_xuat;
    }

    public int getView() {
        return view;
    }

    public void setView(int view) {
        this.view = view;
    }
}
