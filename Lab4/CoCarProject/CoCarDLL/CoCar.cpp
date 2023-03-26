#include "CoCar.h"
#include <tchar.h>
#include <stdio.h>

extern ULONG g_lockCount;
extern ULONG g_objCount;

STDMETHODIMP_(DWORD) CoCar::AddRef()
{
	++m_refCount;
	return m_refCount;
}

STDMETHODIMP_(DWORD) CoCar::Release()
{
	if (--m_refCount == 0)
	{
		delete this;
		return 0;
	}
	else
		return m_refCount;
}

STDMETHODIMP CoCar::QueryInterface(REFIID riid, void** pIFace)
{
	// Which aspect of me do they want?
	if (riid == IID_IUnknown)
	{
		*pIFace = (IUnknown*)(IEngine*)this;
		MessageBox(NULL, _T("Handed out IUnknown"), _T("QI"), MB_OK |
			MB_SETFOREGROUND);
	}

	else if (riid == IID_IEngine)
	{
		*pIFace = (IEngine*)this;
		MessageBox(NULL, _T("Handed out IEngine"), _T("QI"), MB_OK |
			MB_SETFOREGROUND);
	}

	else if (riid == IID_IStats)
	{
		*pIFace = (IStats*)this;
		MessageBox(NULL, _T("Handed out IStats"), _T("QI"), MB_OK |
			MB_SETFOREGROUND);
	}

	else if (riid == IID_ICreateCar)
	{
		*pIFace = (ICreateCar*)this;
		MessageBox(NULL, _T("Handed out ICreateCar"), _T("QI"), MB_OK |
			MB_SETFOREGROUND);
	}
	else
	{
		*pIFace = NULL;
		return E_NOINTERFACE;
	}

	((IUnknown*)(*pIFace))->AddRef();
	return S_OK;
}
// Конструктор и деструктор СоСаr
CoCar::CoCar() : m_refCount(0), m_currSpeed(0), m_maxSpeed(0)
{
	m_refCount = 0;
	m_petName = SysAllocString(L"Default Pet Name");
	++g_objCount;
}

CoCar::~CoCar()
{
	--g_objCount;
	if (m_petName)
		SysFreeString(m_petName);
	MessageBox(NULL, _T("CoCar is dead"), _T("Destructor"), MB_OK |
		MB_SETFOREGROUND);
}

// Реализация IEngine
STDMETHODIMP CoCar::SpeedUp()
{
	m_currSpeed += 10;
	return S_OK;
}

STDMETHODIMP CoCar::GetMaxSpeed(int* maxSpeed)
{
	*maxSpeed = m_maxSpeed;
	return S_OK;
}

STDMETHODIMP CoCar::GetCurSpeed(int* curSpeed)
{
	*curSpeed = m_currSpeed;
	return S_OK;
}

// Реализация ICreateCar
STDMETHODIMP CoCar::SetPetName(BSTR petName)
{
	SysReAllocString(&m_petName, petName);
	return S_OK;
}

STDMETHODIMP CoCar::SetMaxSpeed(int maxSp)
{
	if (maxSp < MAX_SPEED)
		m_maxSpeed = maxSp;
	return S_OK;
}

// Возвращает клиенту копию внутреннего буфера BSTR 
STDMETHODIMP CoCar::GetPetName(BSTR* petName)
{
	*petName = SysAllocString(m_petName);
	return S_OK;
}

// Информация о СоСаr помещается в блоки сообщений
STDMETHODIMP CoCar::DisplayStats()
{
	// Need to transfer a BSTR to a char array.
	char buff[MAX_NAME_LENGTH] = {};
	WideCharToMultiByte(CP_ACP, NULL, m_petName, -1, buff,
		MAX_NAME_LENGTH, NULL, NULL);

	MessageBox(NULL, buff, _T("Pet Name"), MB_OK | MB_SETFOREGROUND);
	memset(buff, 0, sizeof(buff));
	printf(buff, "%d", m_maxSpeed);
	MessageBox(NULL, buff, _T("Max Speed"), MB_OK |
		MB_SETFOREGROUND);
	return S_OK;
}

