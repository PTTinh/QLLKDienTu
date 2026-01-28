#!/bin/bash
# Run script to start the application

echo "=========================================="
echo "CHẠY ỨNG DỤNG QUẢN LÝ BÁN HÀNG"
echo "=========================================="
echo ""

# Path to executable
EXE_PATH="./bin/Debug/QuanLyBanHang.exe"
BAT_FILE="./Build.bat"

# Check if executable exists
if [ ! -f "$EXE_PATH" ]; then
    echo "⚠️  Chưa tìm thấy file chạy: $EXE_PATH"
    echo ""
    echo "📦 Đang biên dịch project..."
    echo ""
    
    # Try to find MSBuild
    if command -v msbuild &> /dev/null; then
        msbuild QuanLyBanHang.csproj /p:Configuration=Debug
    elif [ -f "Build.bat" ]; then
        cmd /c Build.bat
    else
        echo "❌ LỖI: Không thể biên dịch project"
        echo "Vui lòng cài đặt Visual Studio 2022 hoặc .NET Framework 4.7.2"
        exit 1
    fi
fi

# Check again if executable exists
if [ ! -f "$EXE_PATH" ]; then
    echo "❌ LỖI: Không thể tạo file chạy"
    echo "File: $EXE_PATH"
    exit 1
fi

echo "✅ Đã sẵn sàng"
echo ""
echo "📍 Chạy: $EXE_PATH"
echo ""

# Run the application
"$EXE_PATH"
